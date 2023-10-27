<script lang="ts">
	import Link from '$lib/Link.svelte';

	const example1 = `
event["event/e460/E465_002.PM3"]:
  frame_100 = 42
end
`.trim();
</script>

<h2>Events (CLI only)</h2>
<p>
	Edit the BGM used during events. Event BGM editing is an
	<b>advanced</b> topic. <em>Persona Music Script</em> only simplifies changing the BGM, not how or where
	to make changes.
</p>
<p>
	For information about Event BGM editing, see: <Link
		url="https://animatedswine37.github.io/persona-modding-docs/audio/event-audio-editing.html"
		text="Event Audio Editing"
	/>
</p>
<blockquote>
	Before editing an event's BGM, place an original copy of the event file you're editing at
	<em>PersonaMusicScript/resources/GAME/original</em>, keeping the original folder structure of the
	file.
</blockquote>
<h3>Event Block</h3>
<div class="row">
	<div class="column">
		<p>
			Between the <code>[ ]</code> brackets, set the relative path of the event file you're editing.
		</p>

		<p>
			<em>Event Blocks</em> only have one command: <code>frame_#</code>, where <code>#</code> is the
			frame number you want to set the music for. The example shown will play Song ID 42 on frame 100.
		</p>
	</div>
	<div class="column">
		<pre><code>{example1}</code></pre>
	</div>
</div>
