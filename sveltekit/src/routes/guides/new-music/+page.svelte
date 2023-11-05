<script lang="ts">
	import { GAME_P4G, GAME_P5R, currentGame } from '$lib/Games';
</script>

<h1>Using New Music</h1>
<p>
	BGM limits are (mostly) no more! All three Persona games now support adding new music, with only
	Persona 4 Golden still having a hard limit.
</p>

<h2>Universal BGM Unlock</h2>
<p>
	New music tracks can be used anywhere in the game, by <em>anything</em>. Music scripts,
	flowscript, even other code mods.
</p>

{#if $currentGame === GAME_P5R}
	<h2>Persona 5 Royal</h2>
	<p>
		<em>BGME Framework</em> adds <b>10,000</b> new music tracks for use. Place new audio tracks in
		<code>FEmulator/AWB/BGM_42.AWB/</code>, with a BGM ID between 0 up to 9999.
	</p>
	<p>
		To use a new audio track, add <code>10000</code> to its BGM ID, then use that value in your music
		script (or anywhere else).
	</p>
	<h3>Example</h3>
	<p>Here's an example showing how you would add and use BGM ID 400.</p>
	<ol>
		<li>
			Place a music file at:
			<code>FEmulator/AWB/BGM_42.AWB/400.adx</code>
		</li>
		<li>Adding <code>10000</code> to the BGM ID gives you: <code>10400</code>.</li>
		<li>Play the new music by using <code>10400</code> in your music script.</li>
	</ol>
{:else if $currentGame === GAME_P4G}
	<h2>Persona 4 Golden</h2>
	<p>
		<em>BGME Framework</em> allows you to use any audio track in <code>snd00_bgm.awb</code> for BGM.
		This means you can't truly <em>add</em> new music, but you can replace then use existing audio tracks
		as music.
	</p>
	<blockquote><b>Tip:</b> Replace and use audio tracks 678 up to 835 for new music.</blockquote>
	<h3>Example</h3>
	<p>Here's an example showing how you would add and use BGM ID 678.</p>
	<ol>
		<li>
			Place a music file at:
			<code>FEmulator/AWB/snd00_bgm.awb/678.hca</code>
		</li>
		<li>Use the new music by using <code>678</code> in your music script.</li>
	</ol>
{:else}
	<h2>Persona 3 Portable</h2>
	<p>
		<em>BGME Framework</em> lets you use any numbered audio track in
		<code>P5REssentials/CPK/BGME/data/sound/bgm/</code>. Max audio track is
		<code>99999999999.adx</code>, in theory at least.
	</p>
	<h3>Example</h3>
	<p>Here's an example showing how you would add and use BGM ID 400.</p>
	<ol>
		<li>
			Place a music file at:
			<code>P5REssentials/CPK/BGME/data/sound/bgm/400.adx</code>
		</li>
		<li>Use the new music by using <code>400</code> in your music script.</li>
	</ol>
{/if}
