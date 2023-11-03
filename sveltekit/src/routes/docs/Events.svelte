<script lang="ts">
	const example1 = `
const introLimoEvent = event(101, 1)
`.trim();

	const example2 = `
const introLimoEvent = event(101, 1)
event[introLimoEvent]:
  frame_100 = 42
end
`.trim();

	const example3 = `
const introLimoEvent = event(101, 1)
event[introLimoEvent]:
  // Options:
  // BGM_ALL STOP
  // BGM_FADE_IN
  // BGM_FADE_OUT
  // BGM_PLAY
  // BGM_VOLUME_DOWN
  // BGM_VOLUME_UP
  // BGM_ALL_STOP
  frame_100 = frame_bgm(BGM_PLAY, 42)
end
`.trim();
</script>

<h2>Events (Persona 4 Golden)</h2>
<p>
	Change when and what BGM is used during events by using the <b>Event Block</b>. Event BGM editing
	is a bit more advanced but <em>Persona Music Script</em> simplifies the process greatly.
</p>
<h3>Setup for Event Editing</h3>
<p>
	First you need to know the <em>Major ID</em> and <em>Minor ID</em> of the event you want to edit,
	including what frames to make changes on. <em>BGME Framework</em> includes a useful feature for showing
	this information in the console.
</p>
<h4>Enable Event Information</h4>
<p>
	In Reloaded, select <em>BGME Framework</em> and click
	<em>Configure Mod</em>. In the config window, change the logging level to <em>Debug</em>.
</p>
<h4>Hot Reload</h4>
<p>
	Changes to events require new files to be built. <em>BGME Framework</em> handles building these
	files but this is only done at the start of the game, by default. If you want changes to events to
	update in real-time, enable <em>Hot Reload</em> in <em>BGME Framework</em> <b>and</b>
	<em>CRI FileSystem V2 Hook</em>.
</p>
<h3>Creating an Event</h3>
<div class="row">
	<div class="column">
		Start by creating a constant, then set it to the event you want to edit using: <code
			>event(majorId, minorId)</code
		>.
	</div>
	<div class="column">
		<pre><code>{example1}</code></pre>
	</div>
</div>
<h3>Event Block</h3>
<div class="row">
	<div class="column">
		<p>
			Between the <code>[ ]</code> brackets, place your event constant.
		</p>

		<p>
			<b>Event Blocks</b> only have one command: <code>frame_#</code>, where <code>#</code> is the frame
			number you want to set the music for. The example shown will play Song ID 42 on frame 100.
		</p>
	</div>
	<div class="column">
		<pre><code>{example2}</code></pre>
	</div>
</div>
<h5>Using Frame BGM</h5>
<p>
	There's also a special type of BGM just for frames, called
	<em>frame_bgm</em>. This BGM lets you use some useful BGM effects, like transitions and stops.
</p>
<pre><code>{example3}</code></pre>
